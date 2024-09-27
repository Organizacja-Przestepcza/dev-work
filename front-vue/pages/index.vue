<script setup lang="ts">


definePageMeta({
    middleware: 'auth'
});

const viewport = useViewport();
const {getCurrentUser} = useAuth();
onMounted(()=>{
     getCurrentUser();
})

const token = useCookie('auth_token').value;
const runtimeConfig = useRuntimeConfig();
const { status, data: posts, refresh } = useFetch(runtimeConfig.public.API_BASE_URL + '/posts', {
    headers: {
        Authorization: `Bearer ${token}`
    },
    lazy: true
});



</script>

<template>
    <div v-if="status === 'pending'">
        Loading ...
    </div>

    <div class="flex flex-col gap-5" v-else>
        <WritePost @upload-post="refresh" />
        <Post v-for="post in posts" :post="post" />
    </div>
</template>
