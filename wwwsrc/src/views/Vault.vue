<template>
    <div class="vault">
        <h3>
            {{vault.name}}
        </h3>


    </div>
</template>
<script>
    export default {
        name: "vault",
        data() {
            return {
                newKeep: {
                    title: "",
                    description: "",
                    vaultId: this.vaultId
                }
            }
        },
        created() {
            if (!this.$store.state.user._id) {
                this.$router.push({ name: "login" });
            }
        },
        computed: {
            vault() {
                return this.$store.state.activeVault
            },
            keeps() {
                return this.$store.state.keeps
            }
        },
        mounted() {
            this.$store.dispatch("getVault", this.vaultId)
            this.$store.dispatch("getKeeps", this.vaultId)
        },
        methods: {

        }

    }


</script>
<style>

</style>