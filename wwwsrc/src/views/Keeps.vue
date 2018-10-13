<template>
    <div class="row">

        <div class="keeps col-12">
            <form @submit.prevent="createKeep">
                <input type="text" placeholder="Name of Keep" v-model="newKeep.name" required>
                <input type="text" placeholder="Description" v-model="newKeep.description" required>
                <input type="url" placeholder="Image url" v-model="newKeep.img" required>
                <button type="submit">Create Keep</button>
            </form>

            <div class="keep col-3 buttons-container" v-for="keep in keeps" :key="keep.id">
                <p>{{keep.name}}</p>
                <img class="image" :src="keep.img" alt="keep">
                <div class="middle btn-group">
                    <button class="btn" @click="deleteKeep(keep)">Delete Keep</button>
                    <button class="btn" @click="viewKeep(keep)" data-toggle="modal" data-target="#viewKeepModal">View
                        Keep</button>
                    <button class="btn" @click="shareKeep(keep)">Share Keep</button>
                    <button class="btn" @click="viewKeep(keep)" data-toggle="modal" data-target="#viewKeepModal">Add To
                        Vault</button>
                </div>
            </div>



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
                            <img :src="activeKeep.img" alt="keep">
                            <p>{{activeKeep.description}}</p>
                            <p>{{activeKeep.views}}</p>
                            <p>{{activeKeep.shares}}</p>
                            <p>{{activeKeep.keeps}}</p>
                            <select name="" id="" v-model="vaultKeep.vaultId">
                                <option :value="vault.id" v-for="vault in vaults">{{vault.name}}</option>
                            </select>
                            <button class="btn" @click="addKeepToVault" data-dismiss="modal">Add Keep To Vault</button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- end view keep modal -->

        </div>
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
            }
        }
    }
</script>

<style scoped>
    .buttons-container {
        position: relative;
        width: 50%;
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
    }

    .buttons-container:hover .image {
        opacity: 0.3;
    }

    .buttons-container:hover .middle {
        opacity: 1;
    }

    .text {
        background-color: #4CAF50;
        color: white;
        font-size: 16px;
        padding: 16px 32px;
    }
</style>