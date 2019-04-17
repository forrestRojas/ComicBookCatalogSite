<template>
    <article>
    <h2>Best User</h2>
    <p>{{this.bestuser}}</p>
    </article>
</template>

<script>
export default {
name: "best-user",
data(){
    return {
        bestuser: 0
    }
},
created(){
    const id = this.$route.params.id;

    fetch(`${process.env.VUE_APP_REMOTE_API}/statistics/bestuser`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(({bestuser}) => this.bestuser = bestuser);
}
}
</script>

<style>

</style>