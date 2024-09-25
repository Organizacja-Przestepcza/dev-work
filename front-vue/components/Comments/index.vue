<script setup lang="ts">
import dayjs from 'dayjs';
import type { Post } from '~/common/models';
const props = defineProps({
    previousPostId: {
        type: String,
        required: true
    }
});

const runtimeConfig = useRuntimeConfig();
const param = props.previousPostId;
const token = useCookie('auth_token').value;
const { data, status, error, refresh } = await useFetch<Post[]>(runtimeConfig.public.API_BASE_URL + "/posts/" + param +"/comments", {

headers: {
    Authorization: `Bearer ${token}`
},
lazy: true
});
const comments = data.value;
</script>
<template>
    <div>
        <div v-if="comments && comments.length > 0" class="flex flex-col gap-5 text-center ">

            <div v-for="comment in comments">
                <span class="w-full text-gray-500 pb-5 pi pi-ellipsis-v"></span>
                <Post :post="comment" class="w-full" />
            </div>


        </div>
        <div v-else>
            <span>No comments found.</span>
        </div>

    </div>
</template>
