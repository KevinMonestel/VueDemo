<template>
  <div class="container">
    <header class="jumbotron">
      <h3>
        <strong>{{jwtData.username}}</strong> Profile
      </h3>
    </header>
    <p>
      <strong>Token:</strong>
      {{ currentUser.token }}
    </p>
    <p>
      <strong>Id:</strong>
      {{jwtData.id}}
    </p>
    <p>
      <strong>Email:</strong>
      {{jwtData.email}}
    </p>
    <strong>Authorities:</strong>
    <p>{{jwtData.role}}</p>
  </div>
</template>

<script>
export default {
  name: 'Profile',
  computed: {
    currentUser() {
      return this.$store.state.auth.user;
    },
    jwtData() {
      if (this.currentUser.token) return JSON.parse(atob(this.currentUser.token.split('.')[1]));
      return {};
    }
  },
  mounted() {
    if (!this.currentUser) {
      this.$router.push('/login');
    }
  },
  methods: {},
};
</script>