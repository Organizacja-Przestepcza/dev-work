<script setup lang="ts">
import type { Chat } from '~/common/models';

const props = defineProps<{
  chat: Chat;
}>();

</script>

<template>
  <button class="flex flex-row items-center">

    <Avatar size="large" :icon="chat?.avatar == '' ? 'pi pi-user' : ''"
      :image="chat?.avatar != '' ? chat?.avatar : undefined" class="mr-2" shape="circle" />

    <span class="inline-flex flex-col items-start">
      <span class="font-bold">{{ chat?.name }}</span>
    </span>

  </button>
</template>