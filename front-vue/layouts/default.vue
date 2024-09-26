<script setup lang="ts">
import { useToast } from "primevue/usetoast";
import type { User } from "~/common/models";
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

const toggle = (event: any) => {
  menu.value.toggle(event);
};

const toast = useToast();
const handleToast = (status: string, isBookmarked: boolean) => {
  console.log(status);
    if (status == 'error') {
        toast.add({ severity: 'error', summary: 'Error occured', detail: 'Unable to bookmark this post.', life: 3000 });
        return;
    }

    if (isBookmarked) {
        toast.add({ severity: 'info', summary: 'Added to Bookmarks', detail: 'Post added to bookmarks.', life: 3000 });
    }
    else if (!isBookmarked) {
        toast.add({ severity: 'info', summary: 'Removed from Bookmarks', detail: 'Post removed from bookmarks', life: 3000 });
    }

}
const currentUser = useState<User>("currentUser");
watchEffect(()=>{
  console.log(currentUser.value);
})
</script>

<template>
  <!-- Sticky navbar with background -->
  <div class="sticky top-0 bg-zinc-900 p-3">
    <div class="flex justify-between items-center">
      <NuxtLink to="/">
        <img src="../assets/img/logov3.svg" alt="Logo" width="40" />
      </NuxtLink>

      <div>
        <IconField>
          <InputText placeholder="Search" />
          <InputIcon class="pi pi-search" />
        </IconField>
      </div>

      <div>
        <div class="flex items-center gap-2">
          <Button severity="secondary">
            <span class="pi pi-bell" style="font-size: 1rem"></span>
            <Badge v-if="notificationCount > 0" :value="notificationCount" />
          </Button>
          <Avatar :icon="currentUser?.avatar == ''? 'pi pi-user':''" :image="currentUser?.avatar != ''? currentUser?.avatar : undefined "  class=" cursor-pointer" shape="circle" @click="toggle" />
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
    <div class="flex w-5/6 mx-auto gap-5 py-5">
        <div class="w-1/5">
            <PostFilterPanel />
        </div>
        <div class="w-3/5">

          <slot @bookmark-click="handleToast" />

        </div>
        <div class="w-1/5 flex flex-wrap gap-5">
            <Card>
                <template #title>Chats</template>
                <template #content>
                    <p class="m-0">
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error
                        repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione
                        quam perferendis esse, cupiditate neque quas!
                    </p>
                </template>
            </Card>

            <Card class="w-full">
                <template #title>Contacts</template>
                <template #content>
                    <ContactTile />
                </template>
            </Card>


        </div>
    </div>
  </div>


</template>
