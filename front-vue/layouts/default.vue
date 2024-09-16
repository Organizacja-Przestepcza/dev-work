<script setup>
const items = ref([
  {
    label: "Search",
  },
]);
const notificationCount = ref(3);
</script>

<template>
  <div class="card">
    <Menubar :model="items">
      <template #start>
        <img src="../assets/img/logov3.svg" alt="Logo" width="40" />
      </template>

      <template #item="{ item, props, hasSubmenu, root }">
        <div class="">
            <InputText
                v-if="item.label === 'Search'"
                placeholder="Search"
                class="w-64"/>
        <div class="">
            <i class="pi pi-bell text-2xl cursor-pointer"></i>
            <Badge v-if="notificationCount > 0" :value="notificationCount" />
        </div>
        
        </div>
        
      </template>

      <template #end>
        <div class="flex items-center gap-2">
          Name
          <Avatar icon="pi pi-user" shape="circle" />
        </div>
      </template>
    </Menubar>
  </div>
</template>
