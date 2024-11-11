
            double numero1 = 0;
            double numero2 = 0;
            string operatore;
            bool inputValido = false;

            // Gestione dell'input del primo numero
            while (!inputValido)
            {
                try
                {
                    Console.WriteLine("Inserisci un numero");
                    numero1 = Convert.ToDouble(Console.ReadLine());
                    inputValido = true;  // Se il numero è valido, esco dal ciclo
                }
                catch (FormatException)
                {
                    Console.WriteLine("Errore: per favore, inserisci un numero valido.");
                }
            }

            inputValido = false; // Reset del flag per il secondo numero

            // Gestione dell'input del secondo numero
            while (!inputValido)
            {
                try
                {
                    Console.WriteLine("Inserisci il secondo numero");
                    numero2 = Convert.ToDouble(Console.ReadLine());
                    inputValido = true;  // Se il numero è valido, esco dal ciclo
                }
                catch (FormatException)
                {
                    Console.WriteLine("Errore: per favore, inserisci un numero valido.");
                }
            }

            // Chiedo all'utente di inserire un operatore matematico
            Console.WriteLine("Inserisci un operatore (+, -, *, /):");
            operatore = Console.ReadLine();

            double risultato = 0;

            try
            {
                switch (operatore)
                {
                    case "+":
                        risultato = numero1 + numero2;
                        break;
                    case "-":
                        risultato = numero1 - numero2;
                        break;
                    case "*":
                        risultato = numero1 * numero2;
                        break;
                    case "/":
                        if (numero2 == 0)
                        {
                            throw new DivideByZeroException("La divisione per zero non è consentita.");
                        }
                        risultato = numero1 / numero2;
                        break;
                    default:
                        throw new InvalidOperationException("Operatore non valido. Per favore, inserisci +, -, *, o /.");
                }

                // Stampa il risultato
                Console.WriteLine($"Il risultato dell'operazione {numero1} {operatore} {numero2} è: {risultato}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Errore: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Errore imprevisto: {e.Message}");
            }

