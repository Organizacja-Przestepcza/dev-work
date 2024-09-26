<script setup lang="ts">
import type { User } from '~/common/models';

const props = defineProps({
    user: {
        type: Object as PropType<User>,
        required: true
    }
})

</script>

<template>
    <button class="flex flex-row items-center">

        <Avatar size="xlarge" :icon="user?.avatar == '' ? 'pi pi-user' : ''"
            :image="user?.avatar != '' ? user?.avatar : undefined" class="mr-2" shape="circle" />

        <span class="inline-flex flex-col items-start">
            <span class="font-bold">{{  user?.displayname ?? user?.username }}</span>
            <span class="text-gray-500">@{{ user?.username }}</span>
        </span>
    </button>
</template>