<template>
   <main id="comic-details">
        <div class="comic-information">
            <h2 id="comic-name">{{comicbook.name}}</h2>

            <section id="comic-publisher">
                <h3>Publisher</h3>
                <p>{{comicbook.publisher}}</p>
            </section>

            <section id="deck">
                <h3>Deck</h3>
                <p>{{comicbook.deck}}</p>
            </section>

            <section id="description">
                <h3>Description</h3> 
                <div v-html="comicbook.description"></div>
            </section>

            <section id="issue-number" class="inline">
                <h3>Issue:</h3>
                <p>No. {{comicbook.issueNumber}}</p>
            </section>

            <section id="volume-number" class="inline">
                <h3>Volume:</h3>
                <p>#{{comicbook.volume}}</p>
            </section>

            <section id="cover-date" class="inline">
                <h3>Cover Date:</h3>
                <p><time :datetime="comicbook.coverDate">{{formatedCoverDate}}</time></p>
            </section>

            <section id="credits">
                <h3>Credits</h3>
                <p>{{comicbook.credits}}</p>
            </section>

        </div>

        <div  id="comic-cover">
            <picture>
                <source v-bind:srcset="comicbook.image">
                <img v-bind:src="comicbook.image" :alt="`Image of ${comicbook.name}, issue ${comicbook.issueNumber}.`" class="comic-photo"/>
            </picture>
            <add-to-collection id="add-to-collection" :comicId="comicbook.id"/>
        </div>
   </main> 
</template>

<script>
import AddToCollection from "@/components/comics/AddToCollection.vue";

export default {
    name: "comic-detail-view",
    components: {
        AddToCollection
    },
    data() {
        return {
            comicbook: {}
        }
    },
    beforeCreate() {
        const { id } = this.$route.params;
        
        fetch(`${process.env.VUE_APP_REMOTE_API}/comic/${id}`, {
            method: "GET",
        })
        .then(response => response.json())
        .then(json => this.comicbook = json);
    },
    create() {

    },
    computed: {
        formatedCoverDate() {
            let {coverDate} = this.comicbook;
            return new Date(coverDate).toDateString();
        }
    },
    watch: {
        $route: function (to, from) {
            if(to !== from){
                let { id } = this.$route.params;

                fetch(`${process.env.VUE_APP_REMOTE_API}/comic/${id}`, {
                    method: "GET",
                })
                .then(response => response.json())
                .then(json => this.comicbook = json);
            }
        }
    }

}
</script>

<style>
.comic-photo {
    object-fit: scale-down;
    width: 250px;
    padding: 5px;
    border: 2pt solid;
    border-color: var(--carmine-pink);
    background-color: var(--black-olive);
    box-shadow: 5px 5px var(--black-olive);
    /* transform: rotate(2deg); */
}

#comic-details {
    display: grid;
    grid-template-columns: 1fr auto;
    /* margin-top: 20px; */
    /* padding: 2em; */
    /* padding-left: 0; */
    column-gap: 20px;
    align-items: center;
}

#comic-cover {
    padding: 10vh 2em 0;
    background-color: #7b7676;
    display: grid;
    height: 100%;
}

.comic-information {
    padding-top: 8px;
    display: grid;
    text-align: right;
    column-gap: inherit;
    grid-template-areas: 
    "title title"
    "desc ."
    "desc ."
    "desc ."
    "desc ."
    "desc ."
    "desc .";
}

 #comic-name {
    font-family: Bangers, sans-serif;
    font-size: 2em;
    letter-spacing: 1pt;
    color: var(--carmine-pink);
    grid-area: title;
 }

#description {
    text-align: left;
    grid-area: desc;
}

#description > div {
    direction: rtl;
    overflow: auto;
    height: 80vh;
    min-height: 400px;
}

#description > div * {
    direction: initial;

}

.comic-information h2, 
.comic-information section p,
.comic-information section h3 {
    margin: 0;
}

.comic-information section {
    margin-bottom: 1em;
}

.inline h3, 
.inline p {
    display: inline-block;
}

.inline :not(:last-child) {
    margin-right: 1ch;
}
#description p{
    margin-bottom: 1em;
}

@media screen and (max-width: 1375px){
    .comic-information {
        padding-top: 8px;
        display: grid;
        text-align: right;
        column-gap: inherit;
        grid-template-areas: 
        "title"
        " ."
        " ."
        " ."
        " ."
        " ."
        " ."
        "desc";
        text-align: left;
    }
}

@media screen and (max-width: 1024px){
    #comic-details {
        grid-template-columns: 1fr;
    }

    #comic-cover {
        display: flex;
        order: -1;
        justify-content: space-between;
        align-items: center;
        padding: 1em;
    }
}

@media screen and (max-width: 760px) {
      #comic-details, .comic-information, #comic-cover {
    justify-content: center;
    flex-direction: column;
  }

    .comic-information, #description {
    text-align: center;
  }
}

</style>

