<template>
    <div class="flex"> <!--! need to figure out how to handle mobile -->
      <!-- Left panel (for menu)-->
      <div class="w-0 md:w-1/5 p-4 h-screen text-center">
        This is the left panel.
      </div>
  
      <!-- Main area -->
      <div class="flex-grow p-4 text-center">
        <slot/>
      </div>
  
      <!-- Right panel (for friends)-->
      <div class="w-0 md:w-1/5 p-4 h-screen text-center"> 
        This is the right panel.
      </div>
    </div>
  </template>
  