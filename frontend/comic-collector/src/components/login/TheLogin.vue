<template>
    <article id="login-component">
        <user v-if="isAuthenticated" v-bind:id="user.id"></user>
        <ul v-if="isAuthenticated" class="dropdown">
          <li><a v-if="isAuthenticated" href="/logout" v-on:click.prevent="logout">Logout</a></li>
        </ul>
        <router-link v-else to="/login">Login</router-link>
    </article>
</template>

<script>
import auth from "@/shared/auth";
import User from "@/components/login/User.vue";

export default {
  name: "the-login",
  components: {
    User
  },
  data() {
    return {
      isAuthenticated: auth.getUser() !== null,
      user: {},
    };
  },
  methods: {
    /**
     * Logs the user out and takes them to the login page
     * @function
     */
    logout() {
      auth.destroyToken();
      this.$router.push("/login");
    }
  },
  computed: {
    getUser() {
      return auth.getUser();
    },
  }, 
  created() {
    fetch(`${process.env.VUE_APP_REMOTE_API}/user/${auth.getUser().sub}`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(json => this.user = json);
  }
}
</script>

<style>
  #login-component {
    display: flex;
    position: relative;
    align-items: baseline;
  }
  
  #login-component > .user {
    position: relative;
  }

  #login-component:hover .dropdown, .dropdown:hover {
    visibility: visible;
  }

  .dropdown {
    list-style: none;
    visibility: hidden;
    /* overflow-y: auto; */
    position: absolute;
    padding: 0;
    width: inherit;
    border: 3px solid var(--black-olive);
    border-top: none;
    background-color: var(--isabelline);
    margin: 0;
    margin-right: -8px;
    right: 0;
    top: 70px;
  }

  .dropdown::before {
    content: '';
    position: absolute;
    margin: 0 41%;
    right: 0px;
    top: -20px;
    width: 0; 
    height: 0; 
    border-left: 10px solid transparent;
    border-right: 10px solid transparent;
    border-bottom: 20px solid var(--isabelline);
  }

  .dropdown li {
    padding: 0;
    margin: 0;
  }

  .dropdown a {
    display: block;
    padding: .5em 2em;
  }

</style>
