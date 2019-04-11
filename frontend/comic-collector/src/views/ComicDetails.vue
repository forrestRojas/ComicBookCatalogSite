<template>
   <main id="details">
        <div class="comic-book-details">
            <h2>{{comicbook.name}}</h2>

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
                <p>{{comicbook.description}}</p>
            </section>

            <section id="issue-number" class="inline">
                <h3>Issue Number:</h3>
                <p>{{comicbook.issuenumber}}</p>
            </section>

            <section id="volume-number" class="inline">
                <h3>Volume:</h3>
                <p>#{{comicbook.volume}}</p>
            </section>

            <section id="cover-date" class="inline">
                <h3>Cover Date:</h3>
                <p>{{comicbook.coverdate}}</p>
            </section>

            <section id="credits">
                <h3>Credits</h3>
                <p>{{comicbook.credits}}</p>
            </section>
        </div>
        <picture>
            <source v-bind:src="comicbook.image">
            <img v-bind:src="comicbook.image" class="comic-photo"/>
        </picture>
   </main> 
</template>

<script>
export default {
    name: "collections-detail-view",
    props: {
        id: Number
    },
    data() {
        return {
            comicbook:{}
        }
    },
    created(){
        const id = this.$route.params.id;
        
        fetch(`${process.env.VUE_APP_REMOTE_API}/comic/${id}`, {
            method: "GET",
        })
        .then(response => response.json())
        .then(json => this.comicbook = json);
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
    transform: rotate(2deg);
}

#details {
    display: grid;
    grid-template-columns: 1fr auto;
    margin-top: 20px;
    column-gap: 20px;
}

#details picture {
    margin-right: 20%;
}

.comic-book-details {
    margin-left: auto;
    margin-top: auto;
    margin-bottom: 1em;
    text-align: right;
    align-self: end;
}

.comic-book-details h2, 
.comic-book-details section p,
.comic-book-details section h3 {
    margin: 0;
}

.comic-book-details section {
    margin-bottom: 1em;
}

.inline h3, 
.inline p {
    display: inline-block;
}

.inline :not(:last-child) {
    margin-right: 1ch;
}
</style>

