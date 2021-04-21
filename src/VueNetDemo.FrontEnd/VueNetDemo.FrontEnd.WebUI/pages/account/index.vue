<template>
    <div class="w-full container mx-auto md:w-9/12">
         <p>
          <strong>Username:</strong>
          {{ $auth.user.userName }}
        </p>
        <p>
          <strong>Email:</strong>
          {{ $auth.user.email }}
        </p>
        <p>
          <strong>Is admin:</strong>
          {{ $auth.user.role === "Admin" }}
        </p>
        <p>
          <strong>Is customer:</strong>
          {{ $auth.user.role === "Customer" }}
        </p>
        <p>
          <strong>User info ($auth.user):</strong>
          {{ $auth.user }}
        </p>
    </div>
</template>

<script>
    export default {
        name: 'account',
    }
</script>

<style>

</style>