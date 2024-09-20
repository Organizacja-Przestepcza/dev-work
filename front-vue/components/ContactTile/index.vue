<script lang="ts" setup>
import type { Contact } from '~/common/models';

const props = defineProps({
  contacts: {
    type: Object as PropType<Contact[]>,
    required: true
  }
});

</script>

<template>
  <div v-if="contacts.length>0">
    <button v-for="contact in contacts"
    class="relative overflow-hidden w-full border-0 bg-transparent flex items-start p-2 pl-4 hover:bg-surface-100 dark:hover:bg-surface-800 rounded-none cursor-pointer transition-colors duration-200">
    <Avatar :image="contact.avatar" class="mr-2" shape="circle" />
    <span class="inline-flex flex-col items-start">
      <span class="font-bold">{{ contact.username }}</span>
    </span>
  </button>
  </div>
  <div v-else>
    <span>No contacts found.</span>
  </div>
</template>