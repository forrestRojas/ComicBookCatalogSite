<template>
<article>
<h2>New User</h2>
    <form>
        <label for="form-username">Name:</label>
            <input id="form-username" v-model="username" type="text" name="name"/>

        <label for="user-bio">Bio:</label>
            <input id="user-bio" v-model="userbio" type="text" name="userbio">

        <label for="favorites">Favorites:</label>
            <input id="favorites" v-model="favorites" type="text" name="favorites">
            <collectiongrid></collectiongrid>
    </form>
</article>
</template>

<script>
import CollectionGrid from '@/components/collections/CollectionsGrid.vue';
import User from '@/components/login/User.vue';


export default {
    data(){
        return{
            username: "",
            userbio: "",
            favorites: "",
            User: ""
        }
        
    },
    created(){

    },
    method(){
        

    }

}
</script>

<style>

</style>
