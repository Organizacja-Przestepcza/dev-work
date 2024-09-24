<script setup lang="ts">
import type { Post } from '~/common/models';

const route = useRoute();
const runtimeConfig = useRuntimeConfig();

const param = route.params.id;
const token = useCookie('auth_token').value;
const { data, status, error, refresh } = await useFetch<Post>(runtimeConfig.public.ROOT_API + "/post/" + param, {

    headers: {
        Authorization: `Bearer ${token}`
    },
    lazy: true
});
watchEffect(() => {
    console.log("data: ", data.value);
    console.log("status: ", status.value);
    console.log("error: ", error.value);
    console.log("refresh: ", refresh);
})

</script>

<template>
    <p>
        {{ data?.content }}
    </p>
    <p>

        {{ data?.createdAt }}
    </p>
    <p>

        {{ data?.imageUrls }}
    </p>
</template>