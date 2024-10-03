<script setup lang="ts">
import type { Post } from '~/common/models';

definePageMeta({
    middleware: 'auth'
});

const {getCurrentUser} = useAuth();

onMounted(()=>{
     getCurrentUser();
})
const token = useCookie('auth_token').value;
const runtimeConfig = useRuntimeConfig();

const { status, data: posts, refresh } = useFetch<Post[]>(runtimeConfig.public.API_BASE_URL + '/posts', {
    headers: {
        Authorization: `Bearer ${token}`
    },
    lazy: true
});

const toast = useToast();

const handleToast = (status: string, isBookmarked: boolean) => {
    if (status == 'error') {
        toast.add({ severity: 'error', summary: 'Error occured', detail: 'Unable to bookmark this post.', life: 3000 });
        return;
    }

    if (isBookmarked) {
        toast.add({ severity: 'info', summary: 'Added to Bookmarks', detail: 'Post added to bookmarks.', life: 3000 });
    }
    else if (!isBookmarked) {
        toast.add({ severity: 'info', summary: 'Removed from Bookmarks', detail: 'Post removed from bookmarks', life: 3000 });
    }

}
</script>

<template>
    <div v-if="status === 'pending'">
        Loading ...
    </div>

    <div class="flex flex-col gap-5" v-else>
        <WritePost @upload-post="refresh" />
        <Post @bookmark-click="handleToast" v-for="post in posts" :key="post.id" :post="post" />
    </div>
    <Toast/>
</template>
