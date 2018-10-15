<template>
    <div class="vault">

        <h2>{{vault.name}}</h2>
        <button @click="deleteVaultKeep(keep)">Remove</button>

        <div v-for="keep in keeps" :key="keep.id">
            <img class="image" :src="keep.img" alt="keep">

            {{keep.name}}

        </div>


    </div>
</template>
<script>
    export default {
        name: "vault",
        data() {
            return {

            }
        },
        created() {
            // if (!this.$store.state.user._id) {
            //     this.$router.push({ name: "login" });
            // }

        },
        computed: {
            vault() {
                return this.$store.state.activeVault
            },
            keeps() {
                return this.$store.state.vaultKeeps
            }
        },
        mounted() {
            this.$store.dispatch("getVault", this.$route.params.vaultId)
            this.$store.dispatch("getVaultKeeps", this.$route.params.vaultId)
        },
        methods: {
            deleteVaultKeep(keep) {
                let vaultKeep = {
                    keepId: keep.id,
                    vaultId: this.vault.id
                }
                this.$store.dispatch("deleteVaultKeep", vaultKeep)

            }
        }

    }


</script>
<style>
    .image {
        object-fit: cover;
        width: 300px;
        height: 300px;
    }
</style>