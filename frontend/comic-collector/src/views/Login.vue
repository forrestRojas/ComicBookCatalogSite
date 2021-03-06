<template>
  <main id="login">
    <section id="content">
      <h2>Login</h2>
      <p>
        Create an account or log in to CCC &mdash; A simple, fun &amp; creative way to capture,
        edit &amp; share your comic collection with friends &amp; family.
      </p>
    </section>
    <section id="login-signup" v-bind:class="{ showSignupForm: !showLoginForm }">
      <form id="login-form" name="login-form" v-if="showLoginForm" v-on:submit.prevent="login" >
        <h2>Welcome Back!</h2>

        <error-message v-bind:error="error"></error-message>

        <label form="login-form" for="email">Username</label>
        <input
          form="login-form"
          v-model.trim="loginForm.username"
          type="text"
          placeholder="Captain America"
          id="email"
        />

        <label form="login-form" for="password">Password</label>
        <input
          form="login-form"
          v-model.trim="loginForm.password"
          type="password"
          placeholder="password"
          id="password"
        />

        <div class="form-actions">
          <button form="login-form" class="login">Log In</button>
          <div class="extras">
            <a v-on:click="toggleForm">Create an Account</a>
          </div>
        </div>
      </form>

      <form id="signup-form" name="signup-form" v-else v-on:submit.prevent="signup">
        <h2>Get Started</h2>

        <error-message :error="error"></error-message>

        <label form="signup-form" for="email2">Username</label>
        <input
          form="signup-form"
          v-model.trim="signupForm.username"
          type="text"
          placeholder="Captain America"
          id="email2"
        />

        <label form="signup-form" for="password2">Password</label>
        <input
          form="signup-form"
          v-model.trim="signupForm.password"
          type="password"
          placeholder="min 6 characters"
          id="password2"
        />

        <label form="signup-form" for="password3">Confirm Password</label>
        <input
          form="signup-form"
          v-model.trim="signupForm.confirmPassword"
          type="password"
          placeholder="confirm password"
          id="password3"
        />

        <div class="form-actions">
          <button form="signup-form">Sign Up</button>
          <div class="extras">
            <a v-on:click="toggleForm">Back to Login</a>
          </div>
        </div>
      </form>
    </section>
  </main>
</template>

<script>
import auth from "@/shared/auth";
import ErrorMessage from "@/components/ui/ErrorMessage.vue";

export default {
  components: { ErrorMessage },
  data() {
    return {
      showLoginForm: true,
      error: "",
      /** Contents of the login form */
      loginForm: {
        username: "",
        password: ""
      },
      /** Contents of the sign up form */
      signupForm: {
        password: "",
        username: "",
        role: "user"
      }
    };
  },
  methods: {
    /**
     * Toggles the showLoginform
     * @function
     */
    toggleForm() {
      this.showLoginForm = !this.showLoginForm;
      this.error = "";
    },
    /**
     * Navigates the user to the home route.
     * @function
     */
    goHome() {
      this.$router.push("/");
    },
    /**
     * Logs the user in and then sends them to the dashboard.
     * NOTE: Uses async/await
     */
    async login() {
      this.error = "";

      /**
       * This example uses async/await over Promise .then()
       * Under the hood it still relies on promises but the syntax of
       * await Promise makes it a bit shorter and easier to read.
       * It also helps with one issue which is the need to conditionally
       * run logic based on the response.statusCode.
       */
      try {
        const url = `${process.env.VUE_APP_REMOTE_API}/account/login`;
        const response = await fetch(url, {
          method: "POST",
          headers: {
            Accept: "application/json",
            "Content-Type": "application/json"
          },
          body: JSON.stringify(this.loginForm)
        });

        if (response.status === 401) {
          this.error = "Your username and/or password is invalid";
          this.loginForm.password = "";
        } else {
          // Parse output and save authentication token
          const token = await response.json();
          auth.saveToken(token);
          this.goHome();
        }
      } catch (error) {
        //console.error(error);
        this.error = "There was an error logging in";
      }
    },
    /**
     * Signs the user up and then redirects them to the dashboard.
     */
    async signup() {
      this.error = "";

      try {
        const url = `${process.env.VUE_APP_REMOTE_API}/account/register`;
        const response = await fetch(url, {
          method: "POST",
          headers: {
            Accept: "application/json",
            "Content-Type": "application/json"
          },
          body: JSON.stringify(this.signupForm)
        });

        // We definitely need the response if success or not.
        const data = await response.json();

        if (response.status === 400) {
          this.error = data.message;
        } else {
          auth.saveToken(data);
          this.goHome();
        }
      } catch (error) {
        //console.error(error);
        this.error = "There was an error attempting to register";
      }
    }
  }
};
</script>

<style scoped>
#login {
  display: flex;
  flex-direction: column;
  background-color: var(--isabelline);
  color: var(--black-olive);
}

#login-signup {
  text-align: left;
}

#content {
  display: block;
  text-align: right;
  background-color: var(--tufts-blue);
  color: var(--isabelline);
}

#content,
#login-signup {
  padding: 5vh 1rem 1rem 1rem;
}

#content h2,
#login-signup h2 {
  margin-top: 0;
  margin-bottom: 2rem;
}

form h2 {
  margin-left: 0;
}

form label {
  font-size: 1rem;
  margin-bottom: 0.5rem;
}

form input {
  width: 100%;
  margin-bottom: 1rem;

  padding: 10px;
  border: 1px solid var(--tufts-blue);
  border-radius: 3px;
}

form label,
form input {
  display: block;
}

form button {
  padding: 0.8rem 1rem;
  background: var(--primary-color);
  background-color: var(--tufts-blue);
  color: var(--isabelline);

  border-radius: 3px;
}

.form-actions {
  display: flex;
}

.form-actions .extras {
  flex: 2;
}

.form-actions .extras {
  text-align: right;
  align-self: center;
}

@media screen and (min-width: 768px) {
  #login-signup {
    padding-top: 10vh;
  }

  #content > *,
  #login-signup form {
    max-width: 80%;
    margin: 0 auto;
  }
}

@media screen and (min-width: 1024px) {
  #content h1,
  #login-signup h1 {
    margin-bottom: 2rem;
  }

  #login {
    flex-direction: row;
  }

  #content,
  #login-signup {
    flex: 1;
    padding: 25vh 1rem 1rem 1rem;
  }

  #login-signup.showSignupForm {
    padding-top: 15vh;
  }
}
</style>
