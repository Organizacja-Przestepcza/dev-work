<template>
  <div class="flex justify-center items-center min-h-screen">
    <div class="flex items-center justify-center">
      <div
        class="flex flex-col-reverse items-center p-5 w-full max-w-5xl md:flex-row flex-wrap md:flex-nowrap md:shadow-2xl md:shadow-green-400 md:border-2 rounded border-green-400">
        <slot />
      </div>
    </div>
  </div>
</template>
