<template>
    <article>
    <h2>Total Collections</h2>
    <p>{{this.totalcollections}}</p>
    </article>
</template>

<script>
export default {
name: "total-collections",
data(){
    return {
        totalcollections: 0
    }
},
created(){

    fetch(`${process.env.VUE_APP_REMOTE_API}/statistics/totalcollections`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(({totalcollections}) => this.totalcollections = totalcollections);
}
}
</script>

<style>

</style>