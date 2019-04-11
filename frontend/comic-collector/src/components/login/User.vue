<template>
    <main id="user">
        <h2>{{user.username}}</h2>
        <picture>
           <source v-bind:src="user.image">
            <img v-bind:src="user.image" class="user-photo"/>
       </picture>
    </main>
</template>

<script>
export default {
name: "user-view",
props: {
    id: Number
},
data(){
    return {
        user: {}
    }
},
watch: {
    id: function (newID, oldID){
        if( newID === undefined || newID === oldID){
            return;
        }
    fetch(`${process.env.VUE_APP_REMOTE_API}/account/${this.id}`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(json => this.user = json);
    }
    },
created(){
    if(this.id){
    fetch(`${process.env.VUE_APP_REMOTE_API}/account/${this.id}`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(json => this.user = json);
    }
}
}
</script>

<style scoped>
    img {
        height: 50px;
    }
</style>
