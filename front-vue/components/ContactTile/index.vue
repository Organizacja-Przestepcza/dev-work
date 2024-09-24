<script lang="ts" setup>
import type { User } from '~/common/models';

const contacts = ref<User[]>([
    {
        avatar: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSXx2xFk_wEb1hLQoDo4Ar3YbhosCPyOCfOgA&s',
        username: 'Catto Catoni'
        
    },
    {
        avatar: 'https://cdn.prod.website-files.com/5ed475eca0977f7f3f4d7105/5edf22fa1ac939ecdd60632a_Untitled-7_0001_pizzacat-meme1.jpg',
        username: 'Catissimo Catani'
    },
    {
        avatar: 'https://tr.rbxcdn.com/31b116ca0b953b6f5565319800bab4be/420/420/Hat/Webp',
        username: 'Kitto Katto'
    }
]);
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