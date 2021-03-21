<template>
  <NavMenu></NavMenu>
  <div class="container">
      <router-view />

      <div class="pt-5 col-4">
          <p>
              Send a notification
          </p>
          <hr />
          <div class="form-group">
              <input class="form-control" placeholder="Notification content..." v-model="notificationContent" />
          </div>
          <div class="form-group">
              <button class="btn btn-dark" v-on:click="SendNotification">Send Notification</button>
          </div>
      </div>
  </div>
</template>

<script>
    import NavMenu from './components/layout/NavMenu.vue';
    import { HubConnectionBuilder } from '@aspnet/signalr';
    import Noty from 'noty';

    export default {
        name: 'App',
        data() {
            return {
                connection: new HubConnectionBuilder().withUrl("http://localhost:38944/api/chatHub").build(),
                notificationContent: ""
            };
        },
        components: {
            NavMenu
        },
        methods: {
            StartNotificationHub() {
                this.connection.start().then(function () {
                    return console.log("Connected to NotificationHub");
                }).catch(function (err) {
                    return console.error(err.toString());
                });
            },
            RecieveNotification() {
                this.connection.on("Receive", function (message) {
                    var audio = new Audio('https://notificationsounds.com/storage/sounds/file-09_dings.ogg');
                    audio.play();

                    new Noty({ 
                        layout: 'bottomRight',
                        text: message,
                        theme: "metroui",
                        type: "info"
                    }).show();
                });
            },
            SendNotification() {
                this.connection.invoke("Send", this.notificationContent).catch(function (err) {
                    return console.error(err.toString());
                });

                this.notificationContent = "New Notification!";
            }
        },
        mounted () {
            this.StartNotificationHub();
            this.RecieveNotification();
        }
    }
</script>

<style>
    @import "~noty/lib/noty.css";
    @import "~noty/lib/themes/metroui.css";
</style>