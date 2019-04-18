<template>
    <main id="user">
        <h2>{{user.username}}</h2>
            
            <section id="image">
            <img v-if="user.image" v-bind:src="user.image" class="user-photo"/>
            <img v-else src="@/assets/default-avatar.jpg" class="user-photo"/>
            
            <form id="image-form">
             <vue-dropzone
                id="dropzone"
                v-bind:options="dropzoneOptions"
                @vdropzone-file-added="afterComplete"
                @vdropzone-sending="sending"
                @vdropzone-success="success"
            ></vue-dropzone>
            </form>
            </section>

            <section id="bio">
            <h3>Bio:</h3>
            <form id="bio-form">
                <textarea form="bio-form" type="text" v-model="updatedUser.bio"></textarea>
            </form>
            <p>{{user.bio}}</p>
            </section>
            
            <section id="favorites">
            <h3>Favorites:</h3>
            <form id="favorites-form">
                <input form="favorites-form" type="text" v-model="updatedUser.favorites">
            </form>
            <p>{{user.favorites}}</p> 
            </section>
                                    
            <section>
            <input type="checkbox" id="premium_checkbox" v-model="checked">
            <label for="checkbox">Upgrade to Premium User</label>
            </section>
            <button type="button" v-on:click="updateProfile" v-if="!showForm">Update Profile</button>
            <button type="button" v-on:click="cancelUpdate" v-if="showForm">Cancel</button>
            <button type="button" v-on:click="saveProfile">Save Profile</button>
    </main>
</template>

<script>
import auth from '@/shared/auth.js';
import createcollection from '@/views/CreateCollection.vue';
import vue2Dropzone from "vue2-dropzone";
import "vue2-dropzone/dist/vue2Dropzone.min.css";

export default {
name: "user-view",
components: {
    vueDropzone: vue2Dropzone
    },
data(){
    return {
        user:{},
        updatedUser: {},
        createcollection:'',
        dropzoneOptions: {
        url: "https://api.cloudinary.com/v1_1/tech-elevator/image/upload",
        thumbnailWidth: 250,
        maxFilesize: 2.0,
        acceptedFiles: ".jpg, .jpeg, .png, .gif",
        uploadMultiple: false
    },
    showForm: false
    }
},
created(){
    const id = this.$route.params.id;

    fetch(`${process.env.VUE_APP_REMOTE_API}/account/${id}`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(json => this.user = json)
    
},
methods: {
    EditUserBio(){
        const p = document.querySelector("#bio p");
        const form = document.querySelector("#bio-form");
        if(p.style.display !=="none"){
        p.style.display="none";
        form.style.display="block";
        }
        else{
            p.style.display="block"
            form.style.display="none";
        }
        // this.$router.push({ path:`/views/${this.user.id}` });
    },
    EditUserFavorites(){
        const p = document.querySelector("#favorites p");
        const form = document.querySelector("#favorites-form");
        if(p.style.display !=="none"){
        p.style.display="none";
        form.style.display="block";
        }
        else{
            p.style.display="block"
            form.style.display="none";
        }
    },
    EditImage(){
        const p = document.querySelector("#image img");
        const form = document.querySelector("#image-form");
        if(p.style.display !=="none"){
        p.style.display="none";
        form.style.display="block";
        }
        else{
            p.style.display="block"
            form.style.display="none";
        }
    },
    sending: function(file, xhr, formData) {
      formData.append("api_key", 714725446462368);
      formData.append("timestamp", (Date.now() / 1000) | 0);
      formData.append("upload_preset", "vg8sew4g");
    },
    success: function(file, response) {
      this.updatedUser.image = response.secure_url;
    },

    saveProfile(){
        this.user.bio = this.updatedUser.bio;
        this.user.favorites = this.updatedUser.favorites;
        this.user.image = this.updatedUser.image;
        fetch(`${process.env.VUE_APP_REMOTE_API}/account/UserDetail`, {
            method: "POST",
            headers: {
                'Content-Type': 'application/json',
                Authorization: 'bearer' + auth.getToken()
            },
        body:JSON.stringify(this.user)
            })
        .then(response => response.json())
        vm.$forceUpdate()
        // this.$router.push({path: `/account/${this.user.id}`})
    } ,
    updateProfile(){
        this.updatedUser.bio = this.user.bio;
        this.updatedUser.favorites = this.user.favorites;
        this.updatedUser.image = this.user.image;
        this.EditUserBio();
        this.EditUserFavorites();
        this.EditImage();
        this.showForm = !this.showForm;
    },
    cancelUpdate(){
        this.updatedUser.bio = this.user.bio;
        this.updatedUser.favorites = this.user.favorites;
        this.updatedUser.image = this.user.image;
        this.updateProfile();
    }
},

watch: {
        $route: function (to, from){
            if( to !== from){
                let id = this.$route.params.id;

                fetch(`${process.env.VUE_APP_REMOTE_API}/account/${id}`, {
                    method: "GET",
                })
                .then(response => response.json())
                .then(json => this.user = json);
            }
        }
},
computed: {
    showForm() {
        return auth.getUser().sub === this.user.username;
    }
}
}
</script>

<style scoped>
    img {
        height: 400px;
        border-radius: 50%;
    }
    #user form{
        display:none;
    }
</style>
<!-- <form v-if="showForm">
        <label for="user-bio">Bio:</label>
            <textarea rows="4" id="user-bio" v-model="userbio" type="text" name="userbio"></textarea>

        <label for="favorites">Favorites:</label>
            <input id="favorites" v-model="favorites" type="text" name="favorites">
            
            <collectiongrid></collectiongrid>

            <input type="checkbox" id="premium_checkbox" v-model="checked">
            <label for="checkbox">Upgrade to Premium User</label>
            <button input type="submit">Submit</button>
    </form> -->