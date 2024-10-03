<script setup lang="ts">
import type { UserRequest } from '~/common/models';

definePageMeta({
  layout: 'basic'
})

const user = ref<UserRequest>({
  username: '',
  password: ''
})

const { login } = useAuth();

const handleLogin = async () => {
  try {
    await login(user.value.username, user.value.password);
    
    navigateTo("/");
  } catch {
    navigateTo("/welcome");
  }

}

</script>

<template>
  <div class="flex flex-col gap-2">
    <div class="flex flex-col gap-2">

      <label for="username">Username</label>
      <InputText v-model="user.username" id="username" type="text" />

    </div>
    <div class="flex flex-col gap-2">
      <label for="password">Password</label>
      <InputText v-model="user.password" id="password" type="password" />
    </div>
    <div class="flex flex-col gap-5 py-2">
      <Button label="Login" @click="handleLogin" class="w-full mx-auto" />
      <Button as="router-link" to="register" label="Don't have an account?" severity="secondary"
        class="w-full mx-auto" />
    </div>
  </div>
</template>