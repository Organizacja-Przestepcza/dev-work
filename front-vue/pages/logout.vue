<script setup lang="ts">
const { logout } = useAuth();
onMounted(()=>{
    logout();
});
</script>