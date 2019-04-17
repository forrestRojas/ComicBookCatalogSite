<template>
    <article>
    <h2>Top Users</h2>
    <p>{{this.topuser}}</p>
    </article>
</template>

<script>
export default {
name: "top-user",
data(){
    return {
        topuser: 0
    }
},
created(){
    const id = this.$route.params.id;

    fetch(`${process.env.VUE_APP_REMOTE_API}/statistics/topuser`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(({topuser}) => this.topuser = topuser);
}
}
</script>

<style>

</style>