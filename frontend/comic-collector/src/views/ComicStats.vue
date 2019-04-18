<template>
    <main id="comicstats">
        <total-collections></total-collections>
        <total-comics></total-comics>
        <publisher></publisher>
        <top-user class="gridareaA"></top-user>
        <largest-collections class="gridareaB"></largest-collections>
        <most-popular class="gridareaC"></most-popular>
        
    </main>
</template>

<script>

import TopUser from '@/components/Stats/TopUser.vue';
import LargestCollections from '@/components/Stats/LargestCollections.vue';
import MostPopular from '@/components/Stats/MostPopular.vue';
import Publisher from '@/components/Stats/Publisher.vue';
import TotalCollections from '@/components/Stats/TotalCollections.vue';
import TotalComics from '@/components/Stats/TotalComics.vue';
export default {
        name: "comic-stats",
    components: {
        TopUser,
        LargestCollections,
        MostPopular,
        Publisher,
        TotalCollections,
        TotalComics
    },

    data(){
        return{
        }
    }

}
</script>

<style>
#comicstats {
    display: grid;
    grid-template-areas: 
        ". . ."
        "a a a"
        "b b b"
        "c c c";
}
.gridareaA {
    grid-area: a;
}
.gridareaB {
    grid-area: b;
}
.gridareaC {
    grid-area: c;
}
</style>

