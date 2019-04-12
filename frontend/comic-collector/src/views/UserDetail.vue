<template>
    <main id="user">
        <h2>{{user.username}}</h2>
        <picture>
           <source v-bind:src="user.image">
            <img v-bind:src="user.image" class="user-photo"/>
       </picture>
       <p>{{user.bio}}</p>
       <p>{{user.favorites}}</p>
       <form v-if="isCurrentUser">
           <input type="checkbox" id="premium_checkbox" v-model="checked">
            <label for="checkbox">Upgrade to Premium User</label>
       </form>
    </main>
</template>

<script>
import auth from '@/shared/auth.js'
export default {
name: "user-view",
data(){
    return {
        user:{},
        isCurrentUser:auth.getUser().sub === user.username
    }
},
created(){
    const id = this.$route.params.id;

    fetch(`${process.env.VUE_APP_REMOTE_API}/account/${id}`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(json => this.user = json);
},
watch: {
        $route: function (to, from){
            if( to !== from){
                let id = this.$route.params.id;

                fetch(`${process.env.VUE_APP_REMOTE_API}/account/${id}`, {
                    method: "GET",
                })
                .then(response => response.json())
                .then(json => this.user = json);
            }
        }
    }
}
</script>

<style scoped>
    img {
        height: 400px;
    }
</style>