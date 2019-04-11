<template>
    <main id="user">
        <h2>{{user.username}}</h2>
        <picture>
           <source v-bind:src="user.image">
            <img v-bind:src="user.image" class="user-photo"/>
       </picture>
       <p>{{user.bio}}</p>
       <p>{{user.favorites}}</p>
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
        user:{}
    }
},
created(){
    const id = this.$route.params.id;

    fetch(`${process.env.VUE_APP_REMOVE_API}/user_datails/${id}`, {
        method: "GET",
    })
    .then(respsonse => resposne.json())
    .then(json => {
        this.user = json;
    });
}
}

</script>

<style>

</style>