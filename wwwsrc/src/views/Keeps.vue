<template>


    <div class="keeps container">
        <div class="create mt-3 mb-3">
            <h4>New keep</h4> <i class="add-icon fas fa-plus fa-3x" data-toggle="modal" data-target="#createKeepModal"></i>
        </div>
        <!-- <div class="row"> -->


        <div class="row all-of-keeps mt-3 ">
            <div class="keep col-3 p-2 buttons-container keep-card" v-for="keep in keeps" :key="keep.id">
                <img class="card-image" :src="keep.img" alt="keep">
                <p class="my-3">{{keep.name}}</p>
                <div class="middle btn-group d-flex flex-column">
                    <button class="btn" @click="deleteKeep(keep)">Delete Keep</button>
                    <button class="btn" @click="viewKeep(keep)" data-toggle="modal" data-target="#viewKeepModal">View
                        Keep</button>
                    <button class="btn" @click="shareKeep(keep)">Share Keep</button>
                    <button class="btn" @click="editKeep(keep)" data-toggle="modal" data-target="#editKeepModal">Edit
                        Keep</button>
                    <button class="btn" @click="viewKeep(keep)" data-toggle="modal" data-target="#viewKeepModal">Add
                        To
                        Vault</button>
                </div>
            </div>
        </div>
        <!-- </div> -->

        <!-- create a keep modal  -->
        <div class="modal fade" id="createKeepModal" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Create A Keep:</h5>
                        <button type="button" class="close" data-dismiss="modal">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form @submit.prevent="createKeep" class="d-flex flex-column">
                            <input type="text" placeholder="Title..." v-model="newKeep.name" required>
                            <input type="text" placeholder="Description..." v-model="newKeep.description" required>
                            <input type="url" placeholder="Image url..." v-model="newKeep.img" required>
                            <button type="submit" @click="createKeep(newKeep)" data-dismiss="modal">Create Keep</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <!-- end of create a keep modal -->



        <!--View Keep Modal -->
        <div class="modal fade" id="viewKeepModal" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">{{activeKeep.name}}</h5>
                        <button type="button" class="close" data-dismiss="modal">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <img class="image rounded" :src="activeKeep.img" alt="keep">
                        <p>{{activeKeep.description}}</p>
                        <p>Views: {{activeKeep.views}}</p>
                        <p>Shares: {{activeKeep.shares}}</p>
                        <p>Keeps: {{activeKeep.keeps}}</p>
                        <select name="" id="" v-model="vaultKeep.vaultId">
                            <option :value="vault.id" v-for="vault in vaults">{{vault.name}}</option>
                        </select>
                        <button class="btn" @click="addKeepToVault" data-dismiss="modal">Add Keep To Vault</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- end view keep modal -->

        <!-- edit keep modal -->
        <div class="modal fade" id="editKeepModal" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Edit Keep: {{activeKeep.name}}</h5>
                        <button type="button" class="close" data-dismiss="modal">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form @submit.prevent="saveKeep" class="d-flex flex-column">
                            <input type="text" placeholder="Name of Keep" v-model="activeKeep.name" required>
                            <input type="text" placeholder="Description" v-model="activeKeep.description" required>
                            <input type="url" placeholder="Image url" v-model="activeKeep.img" required>
                            <button type="submit" data-dismiss="modal">Edit Keep</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <!-- end of edit keep modal -->

    </div>

</template>

<script>
    export default {
        name: 'keeps',
        data() {
            return {
                newKeep: {
                    isPrivate: 0
                },
                activeKeep: {},
                vaultKeep: {}
            }
        },
        computed: {
            keeps() {
                return this.$store.state.keeps
            },
            vaults() {
                return this.$store.state.vaults
            }
        },
        methods: {
            deleteKeep(keep) {
                this.$store.dispatch("deleteKeep", keep);
            },
            createKeep() {
                this.$store.dispatch("createKeep", this.newKeep);
                this.newKeep = { name: "", description: "", img: "", isPrivate: 0 }
            },
            viewKeep(keep) {
                keep.views++
                this.activeKeep = keep;
                this.$store.dispatch("updateKeep", keep)
            },
            shareKeep(keep) {
                keep.shares++
                this.activeKeep = keep;
                this.$store.dispatch("updateKeep", keep)
            },
            addKeepToVault() {
                this.vaultKeep.keepId = this.activeKeep.id;
                this.$store.dispatch("addKeepToVault", { vaultKeep: this.vaultKeep, keep: this.activeKeep })
            },
            editKeep(keep) {
                this.activeKeep = keep;
            },
            saveKeep() {
                this.$store.dispatch("updateKeep", this.activeKeep)
            }
        }
    }
</script>

<style scoped>
    .add-icon:hover {
        color: rgb(86, 228, 185);
        cursor: pointer;
    }

    .keep-card {

        box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
        transition: 0.3s;
        height: 30vh;
        width: 20vw;
        border-radius: 12px;
    }

    /* .container {
        padding: 2px 16px;
    } */

    .buttons-container {
        position: relative;

    }

    .card-image {
        object-fit: cover;
        width: 100%;
        height: 100%;
        border-radius: 12px;
    }

    .image {
        opacity: 1;
        display: block;
        width: 200px;
        height: 200px;
        transition: .5s ease;
        backface-visibility: hidden;
    }

    .middle {
        transition: .5s ease;
        opacity: 0;
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
        -ms-transform: translate(-50%, -50%);
        text-align: center;
        width: 100%;
        display: flex;
        flex-wrap: wrap;
    }

    .buttons-container:hover .image {
        opacity: 0.3;
    }

    .buttons-container:hover .middle {
        opacity: 0.7;
    }

    .all-of-keeps {
        column-width: 40rem;
        font-family: 'Roboto', sans-serif;

    }

    .keep {
        margin: 2rem;
        break-inside: avoid;
    }

    .row {
        margin: 0;
        justify-content: center;
    }

    .btn {
        color: rgba(51, 1, 1, 0.835);
        background-color: white;
        font-family: 'Montserrat', sans-serif;
        font-weight: bold;

    }
</style>