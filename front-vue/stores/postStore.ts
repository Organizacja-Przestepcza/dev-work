import { defineStore } from "pinia";
import type {Post} from "@/common/models";
export const usePostStore = defineStore({
  id: "post",
  state: () => ({
    posts: [] as Post[],
  }),
  actions: {
    
  },
});