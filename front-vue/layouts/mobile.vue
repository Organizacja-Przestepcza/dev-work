<script setup lang="ts">

const activeButton = ref("Home");
const setActiveButton = (label: string) => {
  activeButton.value = label;
};
</script>

<template>
  <slot />

  <div class="w-full bg-zinc-900 absolute bottom-0 p-5">
    <div class="flex justify-evenly items-center">
      <Button
        :severity="activeButton === 'Home' ? 'success' : 'secondary'"
        as="router-link"
        to="home"
        icon="pi pi-home"
        @click="setActiveButton('Home')"
      />
      <Button
        :severity="activeButton === 'Chat' ? 'success' : 'secondary'"
        as="router-link"
        to="chat"
        icon="pi pi-comment"
        @click="setActiveButton('Chat')"
      />
      <Button
        :severity="activeButton === 'Settings' ? 'success' : 'secondary'"
        as="router-link"
        to="settings"
        icon="pi pi-cog"
        @click="setActiveButton('Settings')"
      />
    </div>
  </div>

</template>
