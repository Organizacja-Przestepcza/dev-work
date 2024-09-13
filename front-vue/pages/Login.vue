<script setup lang="ts">
definePageMeta({
  layout: 'basic'
})
</script>

<template>
  <div class="flex flex-col gap-2">
    <div class="flex flex-col gap-2">
      <label for="username">Username</label>
      <InputText id="username" type="text" />
    </div>
    <div class="flex flex-col gap-2">
      <label for="password">Password</label>
      <InputText id="password" type="password" />
    </div>
    <div class="flex flex-col gap-5 py-2">
      <Button label="Login" class="w-full mx-auto"/>
      <NuxtLink to="register">
        <Button label="Don't have an account?" severity="secondary" class="w-full mx-auto"/>
      </NuxtLink>
    </div>
  </div>
</template>