<template>
    <div class="row">

        <div class="keeps col-12">
            <form @submit.prevent="createKeep">
                <input type="text" placeholder="Name of Keep" v-model="newKeep.name" required>
                <input type="text" placeholder="Description" v-model="newKeep.description" required>
                <input type="url" placeholder="Image url" v-model="newKeep.img" required>
                <button type="submit">Create Keep</button>
            </form>

            <div class="keep col-3" v-for="keep in keeps" :key="keep.id">
                <p>{{keep.name}}</p>
                <img :src="keep.img" alt="keep" width="200" height="200">
                <p>{{keep.description}}</p>
                <button @click="deleteKeep(keep)">Delete Keep</button>
            </div>
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
                }
            }
        },
        computed: {
            keeps() {
                return this.$store.state.keeps
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
        }
    }
</script>

<style scoped>

</style>