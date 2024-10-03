<template>
    <div class="chat-container">
        <div class="messages">
            <div v-for="(message, index) in messages" :key="index" class="flex">
                <div class="w-1/5"><Avatar /></div>
                <span class="text w-4/5">{{ message.text }}</span>
            </div>
        </div>
        <input v-model="newMessage" @keyup.enter="sendMessage" placeholder="Type a message..." />
    </div>
</template>

<script>
export default {
    data() {
        return {
            messages: [],
            newMessage: ''
        };
    },
    methods: {
        sendMessage() {
            if (this.newMessage.trim() !== '') {
                this.messages.push({ username: 'You', text: this.newMessage });
                this.newMessage = '';
            }
        }
    }
};
</script>
