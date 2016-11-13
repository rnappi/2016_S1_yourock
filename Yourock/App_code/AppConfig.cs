using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yourock.App_code
{
    public static class AppConfig
    {
        // APPLICATION FILES
        public const string XML_FILE_USERS = "users.xml";
        public const string XML_FILE_CARDS = "cards.xml";
        public const string XML_FILE_USER_CARD = "user_card.xml";
        public const string XML_FILE_LOGS = "logs.xml";
        public const string XML_FILE_USER_CARD_EXCHANGE = "user_card_exchange.xml";
        public const string XML_FILE_EXCHANGE = "exchange.xml";

        // ERROR MESSAGES
        public const string ERROR_LOAD_USERS = "Erro ao carregar os usuários. O XML não existe ou foi corrompido.";
        public const string ERROR_SAVE_USERS = "Erro ao salvar os usuários. O XML não está acessível ou você não tem permissão de grvação no diretório.";

        public const string ERROR_LOAD_CARDS = "Erro ao carregar os cards. O XML não existe ou foi corrompido.";
        public const string ERROR_SAVE_CARDS = "Erro ao salvar os cards. O XML não existe ou foi corrompido.";

        public const string ERROR_LOAD_LOGS = "Erro ao carregar os logs. O XML não existe ou foi corrompido.";
        public const string ERROR_SAVE_LOGS = "Erro ao salvar os logs. O XML não existe ou foi corrompido.";

        public const string ERROR_LOAD_USER_CARDS = "Erro ao carregar os cards do usuário. O XML não existe ou foi corrompido.";
        public const string ERROR_SAVE_USER_CARDS = "Erro ao atualizar os cards do usuário. O XML não existe ou foi corrompido.";

        public const string ERROR_LOAD_EXCHANGE = "Erro ao carregar as trocas. O XML não existe ou foi corrompido.";
        public const string ERROR_SAVE_EXCHANGE = "Erro ao atualizar o XML de trocas. O XML não existe ou foi corrompido.";

        public const string ERROR_LOAD_USER_CARD_EXCHANGE = "Erro ao carregar as permissões para troca do usuário. O XML não existe ou foi corrompido.";
        public const string ERROR_SAVE_USER_CARD_EXCHANGE = "Erro ao atualizar as permissões para troca do usuário. O XML não existe ou foi corrompido.";

        // USER TYPES
        public const string TYPE_USER_PLAYER = "user";
        public const string TYPE_USER_ADMIN = "admin";

        // BOOK CONFIGURATION
        public const int NUMBER_OF_CARDS = 20;
        public const string IMAGE_DIRECTORY = "images/";
        public const int BONUS_CARDS = 3;
    }
}