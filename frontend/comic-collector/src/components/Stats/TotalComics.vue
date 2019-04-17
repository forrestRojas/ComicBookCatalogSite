<template>
    <article>
    <h2>Total Comics</h2>
    <p>{{this.totalcomics}}</p>
    </article>
</template>

<script>
export default {
name: "total-comics",
data(){
    return {
        totalcomics: 0
    }
},
created(){
    fetch(`${process.env.VUE_APP_REMOTE_API}/statistics/totalcomics`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(({totalcomics}) => this.totalcomics = totalcomics);
}
}
</script>

<style>

</style>
