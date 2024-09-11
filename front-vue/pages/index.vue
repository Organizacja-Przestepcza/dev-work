<template>
  <div class="flex items-center justify-center">
    <div
      class="flex flex-col-reverse items-center p-5 md:flex-row w-full md:w-3/4 flex-wrap md:flex-nowrap md:shadow-2xl md:shadow-green-400 md:border-2 rounded border-green-400"
    >
      <div class="w-full md:w-1/2 px-5">
        <div class="text-center py-5">
          <p class="text-2xl">Connect with like-minded people at</p>
          <h1 class="text-5xl text-nowrap">dev-work</h1>
        </div>
        <div class="flex justify-center gap-5 w-full mx-auto text-nowrap">
          <Button label="Sing up" severity="success" />
          <Button label="Sign in" severity="secondary" />
        </div>
      </div>
      <div class="w-full md:w-1/2 p-5">
        <img
          class="w-[12rem] mx-auto"
          src="../assets/img/logov2.svg"
          alt="Developer working on a laptop"
        />
      </div>
    </div>
  </div>
</template>
