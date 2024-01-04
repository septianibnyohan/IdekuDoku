using IdekuDoku.Models.Dto.Va;
using IdekuDoku.Models.Dto.Va.Payment.Response;
using IdekuDoku.Domain.Entities;

namespace IdekuDoku.Api.Services.Va;

public interface ITransactionServices
{
  Transaction Create(PaymentResponseDto paymentResponseDto, PaymentCodeInboundDto paymentCodeInboundDto);
  List<Transaction> FindAll();
  Transaction? FindByVANumber(string vaNumber);
  void UpdateByVANumber(string vaNumber);
}