
<script setup lang="ts" >
import type { Chat } from '~/common/models';
const props =defineProps({
    chat: {
        type: Object as () => Chat,
        required: true
    }
});
</script>

<template>
 {{chat.name}}
</template>
