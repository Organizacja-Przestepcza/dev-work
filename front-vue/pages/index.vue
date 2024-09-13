<script setup lang="ts">
definePageMeta({
  layout: "basic",
});
</script>

<template>
  <div class="w-full md:w-1/2 px-5">
    <div class="text-center py-5 md:pt-10">
      <p class="text-xl md:text-2xl">Connect with like-minded people at</p>
      <h1 class="text-3xl md:text-5xl">dev-work</h1>
    </div>
    <div class="flex justify-center pb-5 md:pb-10 gap-3 md:gap-5 w-full mx-auto">
      <Button as="router-link" to="register" label="Sign up" severity="secondary"/>
      <Button as="router-link" to="login" label="Sign in" severity="success" />
    </div>
  </div>
  <div class="w-full md:w-1/2 p-5">
    <img class="w-28 md:w-48 mx-auto" src="../assets/img/logov2.svg" alt="Logo"/>
  </div>
</template>
