<script setup lang="ts">
import type { Post } from '~/common/models';

const route = useRoute();
const runtimeConfig = useRuntimeConfig();

const param = route.params.id;
const token = useCookie('auth_token').value;
const { data, status, error, refresh } = await useFetch<Post>(runtimeConfig.public.API_BASE_URL + "/posts/" + param, {

    headers: {
        Authorization: `Bearer ${token}`
    },
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
    <div class="flex flex-col gap-5">
        <Post @bookmark-click="handleToast" v-if="data" :post="data" />
        <Comment v-if="data" :previous-post-id="data?.id" />
    </div>
  
</template>