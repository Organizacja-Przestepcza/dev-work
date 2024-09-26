<script setup lang="ts">
definePageMeta({
  layout: "basic",
});


const email = ref('');
const username = ref('');
const password = ref('');
const errorMessage = ref('');
const { register } = useAuth();

const handleRegister = async()=>{
  try {
    console.log(email.value, " ", password.value);
    await register(email.value,username.value, password.value);
    navigateTo("/");
  } catch (error) {
    navigateTo("/welcome");
  }
 
}


</script>

<template>
  <div class="flex flex-col gap-4 items-center">

    <!-- Flex row for form sections -->
    <div class="flex flex-col md:flex-row gap-4 w-full items-stretch">

      <!-- Left Form Section -->
      <div class="flex flex-col w-full md:w-1/2 gap-4 flex-grow">
        <div class="flex flex-col gap-2">
          <label for="username">Username</label>
          <InputText v-model="username" id="username" type="text" />
        </div>
        <div class="flex flex-col gap-2">
          <label for="email">Email</label>
          <InputText v-model="email" id="email" type="text" />
        </div>
      </div>

      <!-- Divider -->
      <div class="hidden md:flex items-stretch">
        <Divider layout="vertical" class="h-full"/>
      </div>

      <!-- Right Form Section -->
      <div class="flex flex-col w-full md:w-1/2 gap-4 flex-grow">
        <div class="flex flex-col gap-2">
          <label for="password">Password</label>
          <InputText v-model="password" id="password" type="password" />
        </div>
        <div class="flex flex-col gap-2">
          <label for="repassword">Re-enter password</label>
          <InputText id="repassword" type="password" />
        </div>
      </div>
    </div>

    <!-- Register Button -->
    <div class="flex flex-col md:flex-row-reverse md:justify-evenly gap-5 w-full pt-2">
      <Button @click="handleRegister" label="Register" class="w-full mx-auto"/>
      <Button as="router-link" to="login" severity="secondary" label="Already have an account?" class="w-full mx-auto"/>
    </div>
  </div>
</template>
