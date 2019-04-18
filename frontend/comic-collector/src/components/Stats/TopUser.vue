<template>
    <article>
    <h2>Top Users</h2>
    <div class="topUsers">
        <user class="usertag" 
            v-for="user in topusers" 
            v-bind:key="user.id"
            v-bind:id="user.id"
            :data-comics="user.value"></user>
    </div>
    </article>
</template>

<script>
import User from "@/components/login/User.vue";

export default {
name: "top-user",
components:{
    User
},
data(){
    return {
        // userIds: [],
        topusers: Array
    }
},
created(){
    fetch(`${process.env.VUE_APP_REMOTE_API}/statistics/bestuser`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(json => {this.topusers = json});
},

methods:{
    async getList(){
    let response = await
    fetch(`${process.env.VUE_APP_REMOTE_API}/statistics/bestuser`, {
        method: "GET",
    })
    let json = await response.json();
    this.topusers = json;
    this.getUsers();
    },
        
    // getUsers(){
    // this.userIds.forEach(user => {
    //     fetch(`${process.env.VUE_APP_REMOTE_API}/account/${user.id}`, {
    //         method: "GET",})
    //     .then(response => response.json())
    //     .then(json => this.topusers.push(json));
    // });
    // }
    }
}
</script>

<style>
.usertag::after {
    content: attr(data-comics);
    margin: auto 0;
    padding-left: 1ch;
}
.usertag {
    margin-right: 30px;
    padding-right: 1ch;
}
.topUsers {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
}
</style>