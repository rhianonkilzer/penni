<template>
    <div class="myvaults">
        <div class="create mt-3 mb-3">
            <h4>
                New Vault</h4> <i class="fas fa-plus fa-3x" data-toggle="modal" data-target="#createVaultModal"></i>
        </div>


        <div class="vault" v-for="vault in vaults" :key="vault.id">
            <router-link :to="{name: 'vault', params: {vaultId: vault.id}}">
                {{vault.name}}
            </router-link>
            <button @click="deleteVault(vault)">Delete Vault</button>
        </div>

        <!-- create vault modal -->
        <div class="modal fade" id="createVaultModal" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Create A Vault:</h5>
                        <button type="button" class="close" data-dismiss="modal">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form @submit.prevent="createVault" class="d-flex flex-column">
                            <input type="text" placeholder="Title..." v-model="newVault.name" required>
                            <input type="text" placeholder="Description.." v-model="newVault.description" required>
                            <button type="submit" @click="createVault(vault)" data-dismiss="modal">Create Vault</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <!-- end of modal -->
    </div>
</template>


<script>
    export default {
        name: 'myvaults',
        data() {
            return {
                newVault: {

                }
            }
        },
        created() {

            this.$store.dispatch("getAllVaults")
        },

        computed: {
            vaults() {
                return this.$store.state.vaults
            }
        },
        methods: {
            deleteVault(vault) {
                this.$store.dispatch("deleteVault", vault);
            },
            createVault() {
                this.$store.dispatch("createVault", this.newVault);
                this.newVault = { name: "", description: "" }
            },
        },
        components: {}
    }
</script>


<style scoped>

</style>