<template>
    <main id="home">
        <article>
            <top-user></top-user>
            <largest-collections></largest-collections>
            <most-popular></most-popular>
            <publisher></publisher>
            <total-collections></total-collections>
            <totalComics></totalComics>
        </article>
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
components:{
    TopUser,
    LargestCollections,
    MostPopular,
    Publisher,
    TotalCollections,
    TotalComics
}

}
</script>

<style>

</style>
