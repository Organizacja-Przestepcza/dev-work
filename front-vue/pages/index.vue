<template>
  <div class="flex items-center justify-center">
    <div
      class="flex flex-col-reverse items-center p-5 w-full max-w-5xl md:flex-row flex-wrap md:flex-nowrap md:shadow-2xl md:shadow-green-400 md:border-2 rounded border-green-400"
    >
      <div class="w-full md:w-1/2 px-5">
        <div class="text-center py-5 md:pt-10 ">
          <p class="text-xl md:text-2xl">Connect with like-minded people at</p>
          <h1 class="text-3xl md:text-5xl">dev-work</h1>
        </div>
        <div class="flex justify-center pb-5 md:pb-10 gap-3 md:gap-5 w-full mx-auto">
          <Button label="Sign up" severity="success" />
          <NuxtLink to="/login"><Button label="Sign in" severity="secondary" /></NuxtLink>
          
        </div>
      </div>
      <div class="w-full md:w-1/2 p-5">
        <img
          class="w-28 md:w-48 mx-auto"
          src="../assets/img/logov2.svg"
          alt="Logo"
        />
      </div>
    </div>
  </div>
</template>
