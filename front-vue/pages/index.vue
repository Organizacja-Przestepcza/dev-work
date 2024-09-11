<template>
  <div class="flex flex-col-reverse md:flex-row justify-center items-center w-full md:w-3/4 flex-wrap md:flex-nowrap">
    <div class="w-full md:w-1/2 px-5">
      <div class="text-center">
        <p class="text-2xl">Connect with like-minded people at</p>
        <h1 class="text-5xl">dev-work</h1>
      </div>
      <div class="flex justify-center gap-5 w-full mx-auto text-nowrap py-10">
        <Button label="Sing up" severity="success" />
        <Button label="Sign in" severity="secondary" />
      </div>
    </div>
    <div class="w-full md:w-1/2 p-5">
      <img
        class="w-[20rem] md:w-[40rem] mx-auto"
        src="../assets/img/developer.svg"
        alt="Developer working on a laptop"
      />
    </div>
  </div>
</template>

