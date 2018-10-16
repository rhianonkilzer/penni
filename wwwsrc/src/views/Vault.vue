<template>
    <div class="vault container">
        <h2>{{vault.name}}</h2>
        <div class="row">



            <div class="row all-of-keeps mt-3 ">
                <div class="keep col-3 p-2 buttons-container keep-card" v-for="keep in keeps" :key="keep.id">
                    <img class="card-image" :src="keep.img" alt="keep">
                    <p class="my-3">{{keep.name}}</p>
                    <div class="middle btn-group d-flex flex-column">
                        <button class="btn" @click="deleteVaultKeep(keep)">Remove</button>


                    </div>
                </div>
            </div>

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
    .keep-card {

        box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.3);
        transition: 0.3s;
        height: 30vh;
        width: 20vw;
        border-radius: 12px;
    }

    h2 {
        box-shadow: 0px 4px 8px 0px rgba(0, 0, 0, 0.4);
        border-radius: 10px;

    }

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

    }

    .keep {
        margin: auto;
        break-inside: avoid;
    }

    .row {
        margin: 0;
    }

    .btn {
        color: rgba(51, 1, 1, 0.835);
        background-color: white;
        font-family: 'Montserrat', sans-serif;
        font-weight: bold;

    }
</style>