<script setup>
const notificationCount = ref(3);

const menu = ref();
const items = ref([
  {
    label: 'Manage account',
    items: [
      {
        label: 'View profile',
        icon: 'pi pi-user',
        link: '/profile'
      },
      {
        label: 'Settings',
        icon: 'pi pi-cog',
        link: '/settings'
      },
      {
        label: 'Log Out',
        icon: 'pi pi-sign-out',
        link: '/logout'
      }
    ]
  }
]);

const toggle = (event) => {
  menu.value.toggle(event);
};

</script>

<template>
  <!-- Sticky navbar with background -->
  <div class="sticky top-0 bg-zinc-900 p-3">
    <div class="flex justify-between items-center">
      <NuxtLink to="/home">
        <img src="../assets/img/logov3.svg" alt="Logo" width="40" />
      </NuxtLink>

      <div>
        <IconField>
          <InputText v-model="value1" placeholder="Search" />
          <InputIcon class="pi pi-search" />
        </IconField>
      </div>

      <div>
        <div class="flex items-center gap-2">
          <Button severity="secondary">
            <span class="pi pi-bell" style="font-size: 1rem"></span>
            <Badge v-if="notificationCount > 0" :value="notificationCount" />
          </Button>
          <Avatar icon="pi pi-user" class=" cursor-pointer" shape="circle" @click="toggle" />
          <Menu ref="menu" id="overlay_menu" :model="items" :popup="true">
            <template #item="{ item, props }">
              <NuxtLink :to="item.link" class="flex justify-start gap-2 p-1 pl-3 items-center">
                <span :class="item.icon"></span>
                <span>{{ item.label }}</span>
              </NuxtLink>
            </template>
          </Menu>
        </div>
      </div>
    </div>
  </div>

  <!-- Content section -->
  <div class="overflow-y-auto">
    <slot />
  </div>
  <div class="  overflow-y-auto">
    <slot />
  </div>

</template>
