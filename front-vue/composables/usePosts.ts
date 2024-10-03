export function usePosts() {
    const config = useRuntimeConfig();
    const posts = useState("posts", () => []);
    const status = useState("status", () => "idle");

    const fetchPosts = async (id: string, direction: boolean) => {
        if (posts.value && posts.value.length > 0) {
            console.log("Returning cached posts");
            return posts.value;
        }
        try {
            status.value = "loading";
            console.log("Fetching posts");
            const token = useState("auth_token").value;
            const response = await fetch(
                `${config.public.API_BASE_URL}/posts/${id}?direction=${direction}`,
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            const data = await response.json();
            posts.value = data;
            status.value = "success";
            return data;
        } catch (error) {
            status.value = "error";
            console.error("Error fetching posts", error);
        }
    };

    const fetchPost = async (id: string) => {
        try {
            console.log("Fetching post");
            const response = await fetch(`${config.public.API_BASE_URL}/posts/${id}`);
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            const data = await response.json();
            return data;
        } catch (error) {
            throw new Error(`Error fetching post: ${error}`);
        }
    };

    const refresh = async (id: string, direction: boolean) => {
        posts.value = [];
        return await fetchPosts(id, direction);
    };

    return {
        posts,
        status,
        fetchPosts,
        fetchPost,
        refresh,
    };
}