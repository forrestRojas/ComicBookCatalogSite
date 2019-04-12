<template>
      <main id="new-collection">
    <h2>Create A New Collection</h2>
    <input
        type="text"
        name="Collection"
        id="title"
        autocomplete="off"
        placeholder="Title your collection"
        v-model="collection.title"
     >
    <form id="post-form">
      <vue-dropzone
        id="dropzone"
        v-bind:options="dropzoneOptions"
        @vdropzone-file-added="afterComplete"
        @vdropzone-sending="sending"
        @vdropzone-success="success"
      ></vue-dropzone>
      
      <input
        type="textarea"
        name="Description"
        id="description"
        autocomplete="off"
        placeholder="Enter a description"
        v-model="collection.description"
      >

      <input
        type="radio"
        name="Access"
        id="public"
        value="public"
        autocomplete="off"
        v-model="collection.accesslevel"
      >
      <label for="public">Public</label>
      <input
        type="radio"
        name="Access"
        id="private"
        value="private"
        autocomplete="off"
        v-model="collection.accesslevel"
      >
      <label for="private">Private</label>

      <div class="form-actions">
        <button v-bind:disabled="!canPost" id="create" @click.prevent="submit">Create</button>
        <router-link to="/" tag="button">Cancel</router-link>
      </div>
    </form>
  </main>
</template>

<script>
import vue2Dropzone from "vue2-dropzone";
import "vue2-dropzone/dist/vue2Dropzone.min.css";
// Uncomment me for API Calls
import auth from "@/shared/auth.js";

export default {
    name: 'new-collection',
    components: {
    vueDropzone: vue2Dropzone
    },
    data() {
        return {
      dropzoneOptions: {
        url: "https://api.cloudinary.com/v1_1/tech-elevator/image/upload",
        thumbnailWidth: 250,
        maxFilesize: 2.0,
        acceptedFiles: ".jpg, .jpeg, .png, .gif",
        uploadMultiple: false
      },
      collection: {
        title: "",
        image: "",
        description: "",
        accesslevel: "",
        userID: ""
      },
      hasImage: false,
    };
  },
  computed: {
    canPost() {
      return this.collection.title && this.hasImage && this.collection.description && this.collection.accesslevel;
    }
  },
  methods: {
    afterComplete() {
      this.hasImage = true;
    },
    sending: function(file, xhr, formData) {
      formData.append("api_key", 714725446462368);
      formData.append("timestamp", (Date.now() / 1000) | 0);
      formData.append("upload_preset", "vg8sew4g");
    },
    success: function(file, response) {
      this.collection.image = response.secure_url;
    },
    submit() {

        fetch(`${process.env.VUE_APP_REMOTE_API}/user/${auth.getUser().sub}`, {
            method: "GET",
            })
            .then(response => response.json())
            .then(json => this.collection.userID = json.id)
        .then(
        fetch(`${process.env.VUE_APP_REMOTE_API}/create`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          Authorization: "Bearer " + auth.getToken()
        },
        body: JSON.stringify(this.collection)
      }).then((response) => {
        if(response.ok) {
          this.$router.push('/');
        }
      }))
    }
  }

}
</script>

<style>

</style>
