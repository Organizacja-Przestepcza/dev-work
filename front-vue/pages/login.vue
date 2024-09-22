<script setup lang="ts">

definePageMeta({
  layout: 'basic'
})


const username = ref('');

const password = ref('');
const errorMessage = ref('');
const { login } = useAuth();

const handleLogin = async()=>{
  try {

    console.log(username.value, " ", password.value);
    await login(username.value, password.value);

    navigateTo("/home");
  } catch (error) {
    navigateTo("/");
  }
 
}

</script>

<template>
  <div class="flex flex-col gap-2">
    <div class="flex flex-col gap-2">

      <label for="username">Username</label>
      <InputText v-model="username"  id="username" type="text" />

    </div>
    <div class="flex flex-col gap-2">
      <label for="password">Password</label>
      <InputText  v-model="password" id="password" type="password" />
    </div>
    <div class="flex flex-col gap-5 py-2">
      <Button label="Login" @click="handleLogin" class="w-full mx-auto"/>
      <Button as="router-link" to="register" label="Don't have an account?" severity="secondary" class="w-full mx-auto"/>
    </div>
  </div>
</template>